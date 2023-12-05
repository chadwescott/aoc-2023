import { Component } from '@angular/core';
import { ScratchCardData } from './scratch-cards.data';

@Component({
  selector: 'aoc-scratch-cards',
  templateUrl: './scratch-cards.component.html',
  styleUrls: ['./scratch-cards.component.scss']
})
export class ScratchCardsComponent {
  data = new ScratchCardData;
  points = 0;
  scratchCards = 0;

  ngOnInit() {

    this.data.data.forEach((game, index) => {
      let matchingNumbers = 0;

      game.winningNumbers.forEach((number) => {
        if (game.numbers.find((x) => x === number)) {
          matchingNumbers++;
        }
      });

      if (matchingNumbers > 0) {
        this.points += Math.pow(2, matchingNumbers - 1);
      }

      this.findMatchingNumbers(index);
    });
  }

  private findMatchingNumbers(index: number): void {
    const game = this.data.data[index];
    let matchingNumbers = 0;
    this.scratchCards++;

    game.winningNumbers.forEach((number) => {
      if (game.numbers.find((x) => x === number)) {
        matchingNumbers++;
        this.findMatchingNumbers(index + matchingNumbers);
      }
    });
  }
}
