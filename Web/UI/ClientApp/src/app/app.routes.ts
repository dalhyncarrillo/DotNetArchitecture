import { Routes } from "@angular/router";
import { AuthenticationGuard } from "./shared/guards/authentication.guard";
import { LoginComponent } from "./views/login/login.component";

export const ROUTES: Routes = [
	routeModule("form", "./views/form/form.module#FormModule"),
	routeModule("home", "./views/home/home.module#HomeModule"),
	routeModule("service", "./views/service/service.module#ServiceModule"),
	routeModule("validation", "./views/validation/validation.module#ValidationModule"),

	{ path: "login", component: LoginComponent },
	{ path: "", redirectTo: "login", pathMatch: "full" },
	{ path: "**", redirectTo: "login" }
];

export function routeModule(path: string, loadChildren: string): object {
	return { path, loadChildren, canActivate: [AuthenticationGuard] };
}
