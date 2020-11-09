namespace Tch.HttpClient.Interfaces.Helpers1
{
   internal interface IModelAdapter<TModel>
   {
      string ToJsonText(TModel source);
   }
}