import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationModel } from "../models/authentication.model";
import { ModalService } from "./modal.service";

@Injectable({ providedIn: "root" })
export class AuthenticationService {
	private service = "AuthenticationService";
	private token = "token";

	constructor(
		private readonly http: HttpClient,
		private readonly modalService: ModalService,
		private readonly router: Router) { }

	authenticate(authentication: AuthenticationModel) {
		this.http.post(`${this.service}/Authenticate`, authentication).subscribe((response: string) => {
			this.setToken(response);
			this.router.navigate(["/home"]);
		});
	}

	getAuthenticatedUserId() {
		this.http.get(`${this.service}/GetAuthenticatedUserId`).subscribe((response: number) => {
			this.modalService.alert(`Authenticated UserId: ${response}`);
		});
	}

	logout() {
		if (this.isAuthenticated()) {
			this.http.post(`${this.service}/Logout`, {}).subscribe();
		}

		this.setToken(null);
		this.router.navigate(["/login"]);
	}

	isAuthenticated() {
		return this.getToken() !== null;
	}

	getToken() {
		return sessionStorage.getItem(this.token);
	}

	private setToken(token: string) {
		if (token) {
			sessionStorage.setItem(this.token, token);
		} else {
			sessionStorage.removeItem(this.token);
		}
	}
}
