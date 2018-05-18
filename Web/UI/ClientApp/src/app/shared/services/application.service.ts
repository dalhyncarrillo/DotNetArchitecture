import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { publishReplay, refCount, take } from "rxjs/operators";

@Injectable({ providedIn: "root" })
export class ApplicationService {
	data: any;
	service = "ApplicationService";

	constructor(private readonly http: HttpClient) { }

	get() {
		if (!this.data) {
			this.data = this.http.get(this.service).pipe(
				publishReplay(1), refCount(), take(1)
			);
		}

		return this.data;
	}
}
