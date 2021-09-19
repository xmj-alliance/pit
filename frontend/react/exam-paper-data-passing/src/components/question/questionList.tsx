import { useEffect, useState } from "react";
import MultipleChoice from "src/components/multipleChoice/multipleChoice";
import { ICommonProps } from "src/models/props";
import { IQuestion, IUserScoreStore } from "src/models/question";
import styles from "./questionList.module.css";

export interface IQuestionProps extends ICommonProps {
  data: Partial<{
    questions: IQuestion[],
    isUserAnswerSubmitted: boolean
  }>,
  events: {
    onUserAnswerCorrectStoreChange: (scoreStore: IUserScoreStore) => void
  }
}

const QuestionList = (props: Partial<IQuestionProps>): JSX.Element => {
  const { data, events } = props;

  const [userAnswerCorrectStore, setUserAnswerCorrectStore] = useState({} as IUserScoreStore);

  const handleOnRightChoiceChanged = (isUserAnswerCorrect: boolean, questionID?: string): void => {
    if (!questionID) {
      return;
    }
    const question = data?.questions?.find((q) => q.id === questionID);
    if (!question) {
      return;
    }
    setUserAnswerCorrectStore({
      [questionID]: {
        ...userAnswerCorrectStore[questionID],
        isCorrect: isUserAnswerCorrect,
        score: question.score,
      },
    });
  };

  useEffect(() => {
    events?.onUserAnswerCorrectStoreChange(userAnswerCorrectStore);
  }, [events, userAnswerCorrectStore]);

  if (!data) {
    return (
      <section>
        Loading data...
      </section>
    );
  }

  const { questions } = data;

  if (!questions) {
    return (
      <section>
        Loading questions...
      </section>
    );
  }

  if (questions.length <= 0) {
    return (
      <section>
        no questions found
      </section>
    );
  }

  const questionsToDisplay = questions.map((question) => {
    const {
      id, title, score, choices, rightChoices,
    } = question;

    return (
      <li key={id}>
        {id && (
          <p className={styles.idHolder}>
            <small>
              id:
              {id}
            </small>
          </p>
        )}

        {data.isUserAnswerSubmitted && (
          <p className={styles.idHolder}>
              {
                userAnswerCorrectStore[id]?.isCorrect
                  ? (
                    <small>
                      Great Correct!
                    </small>
                  )
                  : (
                    <small>
                      oh no Incorrect!
                    </small>
                  )
              }
          </p>
        )}

        <h2 className={styles.title}>
          {title}
          <span>
            &nbsp; (score: &nbsp;
            {score}
            pt)
          </span>
        </h2>
        <form action="none">
          <MultipleChoice
            data={{
              questionID: id,
              choices,
              rightChoices,
              isChoiceLocked: data.isUserAnswerSubmitted,
            }}
            events={{
              onRightChoiceChanged: handleOnRightChoiceChanged,
            }}
          />
        </form>
      </li>
    );
  });

  return (
    <section>
      <ul>
        {questionsToDisplay}
      </ul>
    </section>
  );
};

export default QuestionList;
