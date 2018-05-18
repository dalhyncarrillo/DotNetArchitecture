import { Component } from "@angular/core";
import { ApplicationService } from "../../shared/services/application.service";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({ selector: "app-home", templateUrl: "./home.component.html" })
export class HomeComponent {
	constructor(
		private readonly applicationService: ApplicationService,
		private readonly authenticationService: AuthenticationService) { }

	getAuthenticatedUserId() {
		this.authenticationService.getAuthenticatedUserId();
	}

	callServerOnlyOnce() {
		this.applicationService.get().subscribe((response: any) => { console.log(response); });
	}
}
