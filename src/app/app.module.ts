import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CubesComponent } from './cubes/cubes.component';
import { EnginePartsComponent } from './engine-parts/engine-parts.component';
import { ScratchCardsComponent } from './scratch-cards/scratch-cards.component';

@NgModule({
  declarations: [
    AppComponent,
    CubesComponent,
    EnginePartsComponent,
    ScratchCardsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
