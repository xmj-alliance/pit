import { ChangeEvent, useState } from "react";
import { IChoice } from "src/models/choice";
import { ICommonProps } from "src/models/props";
import styles from "./multipleChoice.module.css";

export interface IMultipleChoiceProps extends ICommonProps {
  data: Partial<{
    questionID: string,
    choices: IChoice[],
    rightChoices: IChoice[],
  }>,
}

const MultipleChoice = (props: Partial<IMultipleChoiceProps>): JSX.Element => {
  const [userChoices, setUserChoices] = useState([] as IChoice[]);

  const { data } = props;

  if (!data) {
    return (
      <section className={styles.choices}>
        Initializing...
      </section>
    );
  }

  const {
    questionID, choices, rightChoices,
  } = data;

  if (!questionID) {
    return (
      <section className={styles.choices}>
        Error: question ID not provided
      </section>
    );
  }

  if (!choices) {
    return (
      <section className={styles.choices}>
        Loading question choices...
      </section>
    );
  }

  if (choices.length <= 0) {
    return (
      <section className={styles.choices}>
        Error: No choices found
      </section>
    );
  }

  const onSelectionChange = (e: ChangeEvent<HTMLInputElement>): void => {
    const currentChoice = choices.find((choice) => choice.id === e.target.value);
    if (currentChoice) {
      setUserChoices([currentChoice]);
    }
  };

  const choicesToDisplay = choices.map((choice) => {
    const { id, value } = choice;
    return (
      <label key={id} className={styles.caption}>
        <input
          type="radio"
          name={`answer-${questionID}`}
          value={id}
          onChange={onSelectionChange}
        />
        {value}
      </label>
    );
  });

  const userChoicesToDisplay = userChoices.map((choice) => {
    const { id, value } = choice;
    return (
      <li key={id} className={styles.caption}>
        {value}
      </li>
    );
  });

  const rightChoicesToDisplay = rightChoices?.map((choice) => {
    const { id, value } = choice;
    return (
      <li key={id} className={styles.caption}>
        {value}
      </li>
    );
  });

  return (
    <section className={styles.choices}>

      {
        userChoicesToDisplay.length > 0 && (
        <div>
          <span>user choices:</span>
          <ul>
            { userChoicesToDisplay }
          </ul>
        </div>
        )
      }

      {choicesToDisplay}

      {
        rightChoicesToDisplay && rightChoicesToDisplay.length > 0 && (
        <div>
          <span>right choices:</span>
          <ul>
            { rightChoicesToDisplay }
          </ul>
        </div>
        )
      }

    </section>
  );
};

export default MultipleChoice;
