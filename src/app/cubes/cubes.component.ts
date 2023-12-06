import { Component } from '@angular/core';
import { CubeData } from './cube.data';
@Component({
  selector: 'aoc-cubes',
  templateUrl: './cubes.component.html',
  styleUrls: ['./cubes.component.scss']
})
export class CubesComponent {

  data = new CubeData;
  sum: number = 0;
  powers: number = 0;

  redCubes = 12;
  greenCubes = 13;
  blueCubes = 14;

  ngOnInit() {
    this.data.data.forEach((game) => {
      if (game.cubes.every((cube) => (cube.color === 'red' && cube.count <= this.redCubes)
        || (cube.color === 'green' && cube.count <= this.greenCubes)
        || (cube.color === 'blue' && cube.count <= this.blueCubes))) {
        this.sum += game.game;
      }

      const red = game.cubes.filter((cube) => cube.color === 'red').sort((a, b) => a.count > b.count ? -1 : a.count < b.count ? 1 : 0)[0].count;
      const green = game.cubes.filter((cube) => cube.color === 'green').sort((a, b) => a.count > b.count ? -1 : a.count < b.count ? 1 : 0)[0].count;
      const blue = game.cubes.filter((cube) => cube.color === 'blue').sort((a, b) => a.count > b.count ? -1 : a.count < b.count ? 1 : 0)[0].count;

      this.powers += (red * green * blue);
    });
  }
}
