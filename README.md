הוראות התקנת השרת על מערכת הפעלה WIN10
-----------------------------------------------------------------
1. וודא ששירות ה- IIS מותקן על השרת ושחבילת .NET Core Hosting Bundle מותקנת (אם לא, התקן מכאן - https://dotnet.microsoft.com/en-us/download)
2. צור Website חדש (Sites>Add website)
3. ב-Pysical Path הגדר את התיקיה של קבצי השרת שקיבלת
4. הגדר את פורט השרת להיות 7072 
5. לחץ OK לסיום
6. לחץ על Application Pool וזהה את הapplication שיצרת (אותו שם)
7. בחלונית Actions לחץ על Advanced Settings
8. בשורה הראשונה מופיע הגדרה dotnet clr verion שנה אותה ל- No managed code כדי לעבוד עם .net core
9. חזור ל-WebSite שיצרת ולחץ על Browse*:7072(http) לבדיקת תקינות השרת.
10. על מנת לקבל פניות מהרשת החיצונית הגדר ב-Firewall את הפורט 7072 לקבל פניות HTTP.