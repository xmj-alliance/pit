import { useState } from "react";
import QuestionList from "src/components/question/questionList";
import paperStyles from "src/views/paper.module.css";
import styles from "./paperStore.view.module.css";

const data = {
  questions: [
    {
      id: "d2f4af45-5c5f-4de3-8e3c-bfbb4294aed1",
      type: "type-multipleChoice",
      title: "Q20: After a blast that ran through the clouds, the Angular Biters completely lost their ____.",
      score: 50,
      choices: [
        {
          id: "d0048ae4-d4a7-48b3-9c61-65ad6035f317",
          value: "(A) Gas Station",
        },
        {
          id: "bf30f676-dda7-46ca-a033-7cda652d98ad",
          value: "(B) Music Player",
        },
        {
          id: "2ea6f9cf-2f6c-4b3a-8f8b-61579cee85c7",
          value: "(C) Process Tree",
        },
        {
          id: "1abbc251-9489-4ee7-b1ad-1f8a045d8b1c",
          value: "(D) Response",
        },
      ],
    },
  ],
};

const PaperStoreView = (): JSX.Element => {
  const [score, setScore] = useState(0);

  return (
    <section className={styles.paperStoreView}>
      <header>
        <h1 className={paperStyles.paperTitle}>Super hard exam (with Redux Store)</h1>
        <p className={paperStyles.scoreHolder}>
          <small>Score:&nbsp;</small>
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

export default PaperStoreView;
