export abstract class BaseService{
    private _baseUrl = "http://localhost/api";
    public get baseUrl() {
        return this._baseUrl;
    }

    public generateUrl(path : string){
        return this._baseUrl + path;
    }
}