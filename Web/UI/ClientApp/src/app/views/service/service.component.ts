import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";

@Component({ selector: "app-service", templateUrl: "./service.component.html" })
export class ServiceComponent {
	list: any;

	constructor(private readonly http: HttpClient) {
		this.http.get("https://jsonplaceholder.typicode.com/users").subscribe((response: any) => this.list = response);
	}
}
