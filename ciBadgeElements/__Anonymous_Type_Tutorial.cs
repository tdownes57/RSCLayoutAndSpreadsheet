using System;
using System.Reflection;  // Added 11/18/2021 Thomas Downes 
//
// Anonymous Types 
//
// https://www.tutorialsteacher.com/csharp/csharp-anonymous-type
//
namespace ciBadgeForWeb.Models
{
    public class Anonymous_Type_Tutorial
    {
        //
        // Anonymous Types 
        //
        //  See parameter "routeValues" in the Function definition of "ActionLink" below. 
        //    ---11/18/2021 Thomas Downes
        //
        //   https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper.actionlink?view=aspnetcore-6.0
        //  public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper,
        //                    string linkText, string actionName);
        //
        // Summary:
        //     Returns an anchor element (a element) for the specified link text, action, and
        //     route values.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action.
        //
        //   https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper.actionlink?view=aspnetcore-6.0
        //   routeValues:  <<< [Sent by an anonymously-typed object. ---Thomas D.]
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object is typically
        //     created by using object initializer syntax.  Alternatively, an object of interface
        //     IDictionary<TKey,TValue> instance containing the route parameters.
        //
        //
        // https://www.tutorialsteacher.com/csharp/csharp-anonymous-type
        //
        //  How to access the property of an anonymous type 
        //  https://stackoverflow.com/questions/1203522/how-to-access-property-of-anonymous-type-in-c
        //
        //  See file \Views\Fields\Simple.cshtml, and/or search the project for "new {".
        //
        //    <td>
        //       @*@Html.ActionLink("Edit", "Edit", new { id = item.FieldIndex })*@
        //            <!--                                                  -->
        //            <!-- Anonymous Type.... new { id = item.FieldIndex }  -->
        //            <!--                                                  -->
        //            @Html.ActionLink("Edit This Field", "Edit",
        //                new { id = item.FieldIndex, isAnonymousType = true })
        //
        //   https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper.actionlink?view=aspnetcore-6.0
        //   routeValues:  <<< [Sent by an anonymously-typed object. ---Thomas D.]
        //     An object that contains the parameters for a route. The parameters are retrieved
        //     through reflection by examining the properties of the object. The object is typically
        //     created by using object initializer syntax.  Alternatively, an object of interface
        //     IDictionary<TKey,TValue> instance containing the route parameters.
        //
        public Anonymous_Type_Tutorial()
        {
            //
            // https://www.tutorialsteacher.com/csharp/csharp-anonymous-type
            //
            //Example: Access Anonymous Type
            //
            //  [Below, I added "isAnonymousType = true" just to be a smart-aleck.)
            //
            var student = new { Id = 1, FirstName = "James", LastName = "Bond", isAnonymousType = true };
            
            Console.WriteLine(student.Id); //output: 1
            Console.WriteLine(student.FirstName); //output: James
            Console.WriteLine(student.LastName); //output: Bond

            //student.Id = 2;                //Error: cannot change value
            //student.FirstName = "Steve";  //Error: cannot change value

            //
            //  [Below, I added "isAnonymousType = true" just to be a smart-aleck.)
            //
            var edit_info = new { id = 5, isAnonymousType = true };
            Console.WriteLine(edit_info.id); //output: 1

            // https://stackoverflow.com/questions/1203522/how-to-access-property-of-anonymous-type-in-c

            //
            // System.Reflection.PropertyInfo    
            //
            //   https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper.actionlink?view=aspnetcore-6.0
            //   routeValues:  <<< [Sent by an anonymously-typed object. ---Thomas D.]
            //     An object that contains the parameters for a route. The parameters are retrieved
            //     through reflection by examining the properties of the object. The object is typically
            //     created by using object initializer syntax.  Alternatively, an object of interface
            //     IDictionary<TKey,TValue> instance containing the route parameters.
            //
            Type type_info = edit_info.GetType();
            PropertyInfo[] array_properties = type_info.GetProperties();
            foreach (PropertyInfo each_prop in array_properties)
            {
                if (each_prop.Name == "Checked" && !(bool)each_prop.GetValue(edit_info))
                    Console.WriteLine("awesome!");

                string each_value = (string)each_prop.GetValue(edit_info);
                Console.WriteLine($"Property: {each_prop.Name} Value: {each_value}");
            }

        }



    }
}