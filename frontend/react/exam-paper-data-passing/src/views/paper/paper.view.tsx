import { useState } from "react";
import QuestionList from "src/components/question/questionList";
import paperStyles from "src/views/paper.module.css";
import styles from "./paper.view.module.css";

const data = {
  questions: [
    {
      id: "cab00fc6-5611-4304-8183-741bd344e0bd",
      type: "type-multipleChoice",
      title: "Q17: What is life's greatest illusion?",
      score: 50,
      choices: [
        {
          id: "556163eb-239f-4220-ab80-a235fe7de674",
          value: "(A) Hapiness",
        },
        {
          id: "078a036a-cf85-40b3-9dda-9a8f03422af4",
          value: "(B) Glory",
        },
        {
          id: "0bfefcb9-44f8-4335-b102-b94571b3e53a",
          value: "(C) Innocence",
        },
        {
          id: "0779314f-71b0-4754-821f-ac7c00d534d7",
          value: "(D) Sorrow",
        },
      ],
    },
  ],
};

const PaperView = (): JSX.Element => {
  const [score, setScore] = useState(0);

  return (
    <section className={styles.paperView}>
      <header>
        <h1 className={paperStyles.paperTitle}>Super hard exam</h1>
        <p className={paperStyles.scoreHolder}>
          <small>Score: &nbsp;</small>
          <span>{score}</span>
        </p>
      </header>
      <main className={paperStyles.paperContent}>
        <QuestionList questions={data.questions} />
      </main>
      <footer className={paperStyles.bottomControls}>
        <button type="button"> Submit </button>
      </footer>
    </section>
  );
};

export default PaperView;
