import { Component, OnInit } from "@angular/core";
import { AuthenticationModel } from "../../shared/models/authentication.model";
import { AuthenticationService } from "../../shared/services/authentication.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class LoginComponent implements OnInit {
	authentication = new AuthenticationModel();

	constructor(private readonly authenticationService: AuthenticationService) { }

	ngOnInit() {
		this.authenticationService.logout();
		this.authentication.login = "admin";
		this.authentication.password = "admin";
	}

	ngSubmit() {
		this.authenticationService.authenticate(this.authentication);
	}
}
