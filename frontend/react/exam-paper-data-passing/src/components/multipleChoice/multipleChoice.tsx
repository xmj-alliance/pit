import { IChoice } from "src/models/choice";
import styles from "./multipleChoice.module.css";

export interface IMultipleChoiceProps {
  questionID: string,
  choices: IChoice[]
}

const MultipleChoice = (props: Partial<IMultipleChoiceProps>): JSX.Element => {
  const { questionID, choices } = props;

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

  const choicesToDisplay = choices.map((choice) => {
    const { id, value } = choice;
    return (
      <label key={id} className={styles.caption}>
        <input type="radio" name={`answer-${questionID}`} value={id} />
        {value}
      </label>
    );
  });

  return (
    <section className={styles.choices}>
      {choicesToDisplay}
    </section>
  );
};

export default MultipleChoice;
