import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from "../services/authentication.service";

@Injectable()
export class AuthenticationGuard implements CanActivate {
	constructor(
		private readonly authenticationService: AuthenticationService,
		private readonly router: Router) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
		if (this.authenticationService.isAuthenticated()) { return true; }
		this.router.navigate(["/login"]);
		return false;
	}
}
