interface SelectionStore {
  [key: string]: string[]
}

class Main {

  selectionStore = {} as SelectionStore;

  buildSelectionResult = () => {

    const selectionResult = document.createElement("ul");
    selectionResult.classList.add("resultList");
    
    for (const key in this.selectionStore) {
      const questionLi = document.createElement("li");

      const questionTitle = document.createElement("h2");
      questionTitle.innerText = key;

      const selectionList = document.createElement("ul");
      selectionList.classList.add("selectionList");
      for (const selection of this.selectionStore[key]) {
        const selectionLi = document.createElement("li");
        selectionLi.innerText = selection;
        selectionList.append(selectionLi);
      }

      questionLi.append(questionTitle);
      questionLi.append(selectionList);

      selectionResult.append(questionLi);

    }

    return selectionResult;

  };

  displaySelectionResult = (selectionResult: HTMLUListElement) => {

    const resultSection = document.querySelector("section.results") as HTMLDivElement;
    if (!resultSection) {
      return;
    }

    const resultList = document.querySelector("section.results .resultList") as HTMLUListElement;
    if (!resultList) {
      return;
    }
    resultSection.removeChild(resultList);

    resultSection.append(selectionResult);

    resultSection.classList.remove("squeezed");

  };

  onAppFromSubmit = (e: Event) => {
    e.preventDefault();

    this.selectionStore = {} as SelectionStore;

    const formData = new FormData(e.target as HTMLFormElement);

    formData.forEach((value, key) => {
      if (!this.selectionStore[key]) {
        this.selectionStore[key] = [] as string[];
      }
      this.selectionStore[key].push(value.toString());
    }) 

    this.displaySelectionResult(this.buildSelectionResult());

  };

  bindEvents = () => {
    const appForm = document.querySelector("#appForm");
    if (appForm) {
      appForm.addEventListener("submit", this.onAppFromSubmit);
    }
  };


  /**
   *  Main
   */
  constructor() {

    this.bindEvents();

  }
}

new Main();