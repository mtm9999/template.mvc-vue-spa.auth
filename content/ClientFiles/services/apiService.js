const urlBase = '/api/';
const testUrl = urlBase + 'test';

export default class ApiService {
	constructor(usrSvc) {
		this.usrSvc = usrSvc;
		this.http = this.usrSvc.getHttp();
	}

	testApi() {
		const self = this;
		return {
			getIt: function() {
				return self.http.get(testUrl);
			}
		};
	}
}
