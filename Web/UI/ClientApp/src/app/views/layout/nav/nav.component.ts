import { Component } from "@angular/core";
import { AuthenticationService } from "../../../shared/services/authentication.service";

@Component({ selector: "app-nav", templateUrl: "./nav.component.html" })
export class NavComponent {
	constructor(private readonly authenticationService: AuthenticationService) { }

	logout() {
		this.authenticationService.logout();
	}
}
