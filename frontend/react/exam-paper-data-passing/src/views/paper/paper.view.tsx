import paperStyles from "src/views/paper.module.css";
import styles from "./paper.view.module.css";

const PaperView = (): JSX.Element => (
  <section className={styles.paperView}>
    <header>
      <h1 className={paperStyles.paperTitle}>Super hard exam</h1>
      <p className={paperStyles.scoreHolder}>
        <small>Score:</small>
        <span>100</span>
      </p>
    </header>
    <main className={paperStyles.paperContent}>
      <h2 className={paperStyles.questionTitle}>
        question: blah blah blah blah blah blah blah blah blah
        blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
        blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah
        blah blah blah blah blah blah blah blah
      </h2>
      <div>
        <form className={paperStyles.choices} action="none">
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer1" />
            (A) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer1" />
            (B) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer1" />
            (C) lalala
          </label>
          <label className={paperStyles.optionCaption}>
            <input type="radio" name="answer1" />
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

export default PaperView;
