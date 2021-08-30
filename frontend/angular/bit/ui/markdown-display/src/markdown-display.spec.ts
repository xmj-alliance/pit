import { CommonModule } from "@angular/common";
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import textMarkdown from "./compositions/markdown-display-test-data";
import { MarkdownDisplayComponent } from './markdown-display.component';

describe("Markdown Display test", () => {

  let fixture: ComponentFixture<MarkdownDisplayComponent>;
  let component: MarkdownDisplayComponent;
  let element: HTMLElement;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        CommonModule
      ],
      declarations: [
        MarkdownDisplayComponent
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(MarkdownDisplayComponent);
    component = fixture.componentInstance; // The component instantiation 
    element = fixture.nativeElement; // The HTML reference

  }));

  test('Passing data', () => {

    // test long texts
    const longText = textMarkdown;

    component.MarkdownDisplayProps = {
      content: longText,
      throttle: 10,
    };

    fixture.detectChanges();

    const article = element.querySelector(".mainText") as HTMLDivElement;
    const titleHeading = article.querySelector("h1");

    expect(titleHeading?.innerHTML).toContain("Markdown Text");

    const expectedContentLines = longText.split("\n", component.MarkdownDisplayProps.throttle);
    const actualContentLines = article.innerHTML.split("\n");

    // due to html sanitizations, actual line number may be smaller
    expect(actualContentLines.length).toBeLessThanOrEqual(expectedContentLines.length);

    // test short texts
    const shortText = "Short little text";
    component.MarkdownDisplayProps = {
      ...component.MarkdownDisplayProps,
      content: shortText,
    };
    fixture.detectChanges();
    
    const shortTextExpectedResult = shortText;

    expect(article.textContent).toContain(shortTextExpectedResult);

  });

});