import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { ROUTES } from "./app.routes";
import { LayoutModule } from "./views/layout/layout.module";

@NgModule({
	bootstrap: [AppComponent],
	declarations: [AppComponent],
	imports: [
		BrowserModule,
		RouterModule.forRoot(ROUTES),
		LayoutModule
	]
})
export class AppModule { }
