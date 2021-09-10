import MultipleChoice from "src/components/multipleChoice/multipleChoice";
import { IQuestion } from "src/models/question";
import styles from "./questionList.module.css";

export interface IQuestionProps {
  questions: IQuestion[]
}

const QuestionList = (props: Partial<IQuestionProps>): JSX.Element => {
  const { questions } = props;

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
      id, title, score, choices,
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

        <h2 className={styles.title}>
          {title}
          <span>
            &nbsp; (score: &nbsp;
            {score}
            pt)
          </span>
        </h2>
        <form action="none">
          <MultipleChoice questionID={id} choices={choices} />
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
