export class ResponseApi<T>
{
  public IsSuccess : boolean | undefined;
  public Message : string | undefined;
  public Exception : string | undefined;
  public data : T | undefined;
}
