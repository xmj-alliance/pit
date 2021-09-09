import paperStyles from "src/views/paper.module.css";
import styles from "./paperStore.view.module.css";

const PaperStoreView = (): JSX.Element => (
  <section className={styles.paperStoreView}>
    <header>
      <h1 className={paperStyles.paperTitle}>Super hard exam (with Redux Store)</h1>
      <p className={paperStyles.scoreHolder}>
        <small>Score:</small>
        <span>100</span>
      </p>
    </header>
    <main className={paperStyles.paperContent}>
      <h2 className={paperStyles.questionTitle}> question: blah</h2>
      <div>
        <form className={paperStyles.choices} action="none">
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer2" />
            (A) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer2" />
            (B) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer2" />
            (C) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer2" />
            (D) lalala
          </label>
        </form>
      </div>

    </main>
    <footer className={paperStyles.bottomControls}>
      <button type="button"> Submit </button>
    </footer>
  </section>
);

export default PaperStoreView;
