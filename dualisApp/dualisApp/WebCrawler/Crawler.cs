using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;


namespace dualisApp.WebCrawler
{
    public class Crawler
    {


        public static void GetData()
        {
            //Response response = null;
            //Document website = null;

            /*
             * First Request und data handling
             */
            //publishProgress(1, 6);

            //if (!isNetworkAvailable(activity)) return 2;

         //   try
         //   {
         //       response = LogInRequest(password[0]);
         //   }
         //   catch (IOException exception)
         //   {
         //       return 3; // network connection failed (timeout)
         //   }

         //   try
         //   {
         //       website = response.parse();
         //   }
         //   catch (IOException e)
         //   {
         //       return 5; // parse-error
         //   }

         //   // check whether we are successful logged in or not...
         //   Element element =
         //       website.select("#contentSpacer_IE > h1:contains(Benutzername oder Passwort falsch)").first();
         //   if (element != null)
         //   {
         //       return 4;
         //   }

         //   /*
         //* 2nd Request to handle redirects and extract link to the month scheduler view
         //*/
         //   publishProgress(2, 6);


         //   while (response.hasHeader("REFRESH"))
         //   {
         //       String nextURL = response.header("REFRESH");
         //       Pattern p = Pattern.compile("(?<=URL=).+");
         //       Matcher m = p.matcher(nextURL);
         //       m.find();
         //       nextURL = m.group(0).toString();

         //       if (!isNetworkAvailable(activity)) return 2;

         //       try
         //       {
         //           response = getBasicJsoupClient(nextURL)
         //               .method(Method.GET)
         //               .execute();
         //       }
         //       catch (IOException exception)
         //       {
         //           return 3; // network connection failed (timeout)
         //       }
         //   }

         //   // navigate to the month-view
         //   try
         //   {
         //       website = response.parse();
         //   }
         //   catch (IOException e)
         //   {
         //       return 5; // parse-error
         //   }

         //   element = website.select("#pageTopNavi .nav a:contains(Monatsansicht)").first();
         //   if (element == null)
         //   {
         //       element = website.select("#pageTopNavi .nav a:contains(month)").first();

         //       if (element == null)
         //       {
         //           return 5; // parse-error
         //       }
         //   }

         //   String link = element.attr("href");

            /*
         * 3nd Request to get the current month view from the scheduler and the link to the next one
         */
         //   publishProgress(3, 6);

         //   if (!isNetworkAvailable(activity)) return 2;

         //   try
         //   {
         //       response = getBasicJsoupClient(link)
         //           .method(Method.GET)
         //           .execute();
         //   }
         //   catch (IOException exception)
         //   {
         //       return 3; // network connection failed (timeout)
         //   }

         //   try
         //   {
         //       website = response.parse();
         //   }
         //   catch (IOException e)
         //   {
         //       return 5; // parse-error
         //   }

         //   element = website.select("#tbmonthContainer .tbcontrol a.skipRight").first();
         //   if (element == null)
         //   {
         //       return 5; // parse-error
         //   }

         //   link = element.attr("href");

         //   String currentMonth = website.toString();


         //   /*
         //* 4nd Request to get the next month view from the scheduler
         //*/
         //   publishProgress(4, 6);


         //   if (!isNetworkAvailable(activity)) return 2;

         //   try
         //   {
         //       response = getBasicJsoupClient(link)
         //           .method(Method.GET)
         //           .execute();
         //   }
         //   catch (IOException exception)
         //   {
         //       return 3; // network connection failed (timeout)
         //   }

         //   try
         //   {
         //       website = response.parse();
         //   }
         //   catch (IOException e)
         //   {
         //       return 5; // parse-error
         //   }

         //   element = website.select("#tbmonthContainer .tbcontrol a.skipRight").first();
         //   if (element == null)
         //   {
         //       return 5; // parse-error
         //   }

         //   link = element.attr("href");

         //   String nextMonth = website.toString();


            /*
         * 5nd Request to get the over next month view from the scheduler
         */

            //publishProgress(5, 6);

            //if (!isNetworkAvailable(activity)) return 2;

            //try
            //{
            //    response = getBasicJsoupClient(link)
            //        .method(Method.GET)
            //        .execute();
            //}
            //catch (IOException exception)
            //{
            //    return 3; // network connection failed (timeout)
            //}

            //try
            //{
            //    website = response.parse();
            //}
            //catch (IOException e)
            //{
            //    return 5; // parse-error
            //}

            //String overNextMonth = website.toString();


            /*
         * Parse
         */
            //publishProgress(6, 6);

            //// Reset the whole Table
            //new Delete().from(Course.class).
            //execute();

            //// parse the tables and import it to the database
            //parseTableAndImportCoursesIntoDatabase(currentMonth);
            //parseTableAndImportCoursesIntoDatabase(nextMonth);
            //parseTableAndImportCoursesIntoDatabase(overNextMonth);

            //return 1;
        }

        public async void LogInRequest(String password)
        {
            HttpClientHandler handler = new HttpClientHandler();
            
            var httpClient = new HttpClient(handler);
           
            var uri = new Uri("https://dualis.dhbw.de/scripts/mgrqcgi?APPNAME=CampusNet&PRGNAME=EXTERNALPAGES&ARGUMENTS=-N000000000000001,-N000324,-Awelcome");
            //httpClient.DefaultRequestHeaders.Referrer = uri;

            // httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            var content =  new MultipartFormDataContent();
            content.Add(new StringContent("i14018@hb.dhbw-stuttgart.de"), "usrname");
            content.Add(new StringContent("hales121)\""), "pass");
            content.Add(new StringContent("CampusNet"), "APPNAME");
            content.Add(new StringContent("LOGINCHECK"), "PRGNAME");
            content.Add(new StringContent("clino,usrname,pass,menuno,menu_type,browser,platform"), "ARGUMENTS");
            content.Add(new StringContent("000000000000001"), "clino");
            content.Add(new StringContent("000324"), "menuno");
            content.Add(new StringContent("classic"), "menu_type");
            content.Add(new StringContent(""), "browser");
            content.Add(new StringContent(""), "platform");
           

            var response = await httpClient.PostAsync(uri, content);
            
            // response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();

            String relativePath = "/scripts/mgrqcgi";
            //String email = activity.getSharedPreferences("LOGIN", Context.MODE_PRIVATE).getString("email", "unknown");

            // Create a request using a URL that can receive a post. 
            
            // login to the web app
            //return getBasicJsoupClient(relativePath)
            //    .header("Referer",
            //        "https://dualis.dhbw.de/scripts/mgrqcgi?APPNAME=CampusNet&PRGNAME=EXTERNALPAGES&ARGUMENTS=-N000000000000001,-N000324,-Awelcome")
            //    .data("usrname", email)
            //    .data("pass", password)
            //    .data("APPNAME", "CampusNet")
            //    .data("PRGNAME", "LOGINCHECK")
            //    .data("ARGUMENTS", "clino,usrname,pass,menuno,menu_type,browser,platform")
            //    .data("clino", "000000000000001")
            //    .data("menuno", "000324")
            //    .data("menu_type", "classic")
            //    .data("browser", "")
            //    .data("platform", "")
            //    .method(Method.POST)
            //    .execute();
        }

    }
}


