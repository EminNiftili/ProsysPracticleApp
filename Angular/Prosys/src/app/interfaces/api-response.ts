export interface ApiResponse<TType>{
    statusCode : number;
    message: string;
    data: TType;
}