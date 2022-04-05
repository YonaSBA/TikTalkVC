using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Server
{
    public class SqlDataBaseHandler
    {
        private SqlConnection m_connection = new SqlConnection(String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "DataBase\\SQL\\Tiktalk.mdf")));

        protected DataTable Get(string query)
        {
            // todo add lock?
            try
            { 
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(query, m_connection);

                adapter.Fill(table);
                m_connection.Close();

                return table;
            }
            catch (Exception)
            {
                Console.WriteLine("no database");
                throw new NoDatabaseException();
            }
        }

        protected void Set(string query)
        {
            using (SqlCommand command = new SqlCommand(query, m_connection))
            {
                try
                {
                    m_connection.Open();
                    command.ExecuteNonQuery();
                    m_connection.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("no database");
                    throw new NoDatabaseException();
                }
            }
        }
    }

    public class SqlUsersQueries : SqlDataBaseHandler, IUsersQueries
    {
        private static Tuple<string, string> m_default = new Tuple<string, string>("{\"hospitality\":{\"id\":false,\"chat\":false,\"start_video\":false,\"rename\":false,\"share_screen\":false,\"waiting_room\":false,\"unmute\":false},\"participation\":{\"nickname\":\"", "\",\"volume\":5,\"background\":\"/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCADQAV4DASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwDz+iiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKK0rKzVV8yRfm/hX+7QBXisZpPmb5V/2qsLpsf8AFI1XqKAKLaav8Mn/AH1VOW1kh+8vy/3q2qGXcu1qAOfoq1e2vkt5kf8Aq2/8dqrQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQBYsofOuF3fdX5q2Kz9NX5ZGrQoAKKKKACiiigBskayRsrfxVhyK0cjK38Nb1Y9+u26b/AGqAK9FFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAaGmt8si1oVj2U3l3Hzfdb5a2KACiiigAooooAKx79t103+zWtIyxqzN91aw3bzJGZv4qAG0UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAVqWV15i+XI37z/wBCrLooA6CisuLUJI/lk/eLVhdSh/iVqALlFU21KP8AhVmqnPeSTfK3yr/dWgCS9uvM/dx/d/8AQqp0UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUU5VZm2r96gBtXINPkk+aT5Vq1bWawrub5pP/AEGrVAEMdrDH92Pd/vVNtVf4aKKAGsqt95VaoZLGGT7q7W/2asUUAY89nJD833l/vVXroKz7ux2/vIV/3loAz6KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigArUsrXy18xvvN/wCO1TsofOm3N91a2KACiiigAooooAKKKKACiiigDLv7Xy28xfutVOt6RVkjZW+61YckbRyNG38NADaKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKdCvmTKv95qANayj8u3X+83zVYoooAKKKKACiiigAooooAKKKKACs/Uo/uyf8BatCobmPzLeRaAMWiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACrVgu66X/ZWqtXtN/wBdI3+zQBpUUUUAFFFFABRRRQAUUUUAFFFFABRRRQBgyLtkZf7tNqa5XbdSf71Q0AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAVasrhYZG8z7rVVooA3lZZF3K26nVgqzK25W21Mt9cL/AMtN3+9QBsUVmrqUn8UatTl1Rf4of/HqANCiqP8AaUf/ADzanf2lD/dkoAuUVT/tKH+61N/tKP8A55tQBeorPbVP7sP/AI9UbalM33VVaANSo5Jo4V/eNtrJa8uJPvSN/wABqGgCSWTzJmk/vVHRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB//9k=\",\"stop_video\":false,\"mute\":false,\"share\":false}}");

        string IUsersQueries.GetPassword(string username)
        {
            return Get(String.Format("SELECT PASSWORD FROM USERS WHERE USERNAME = '{0}';", username)).Rows[0].ItemArray[0].ToString();
        }

        bool IUsersQueries.DoesUserExist(string username)
        {
            return Convert.ToBoolean(Get(String.Format("SELECT * FROM USERS WHERE USERNAME = '{0}';", username)).Rows.Count);
        }

        bool IUsersQueries.DoesEmailMatch(string username, string email)
        {
            return Convert.ToBoolean(Get(String.Format("SELECT * FROM USERS WHERE USERNAME = '{0}' AND EMAIL = '{1}';", username, email)).Rows.Count);
        }

        void IUsersQueries.ChangePassword(string username, string password)
        {
            Get(String.Format("UPDATE USERS SET PASSWORD = '{0}' WHERE USERNAME = '{1}';", password, username));
        }

        bool IUsersQueries.DoesPasswordMatch(string username, string password)
        {
            return Convert.ToBoolean(Get(String.Format("SELECT * FROM USERS WHERE USERNAME = '{0}' AND PASSWORD = '{1}';", username, password)).Rows.Count);
        }

        void IUsersQueries.AddNewUser(string username, string password, string email)
        {
            Set(String.Format("INSERT INTO USERS VALUES ('{0}', '{1}', '{2}', '{3}');", username, password, email, m_default.Item1 + username + m_default.Item2));
        }
    }

    public class SqlMeetingsQueries : SqlDataBaseHandler, IMeetingsQueries
    {
        void IMeetingsQueries.AddNewMeeting(MeetingData meeting)
        {
            Set(String.Format("INSERT INTO MEETINGS VALUES ('{0}', '{1}', '{2}');", meeting.start, meeting.end, string.Join(",", meeting.participants)));
        }

        List<MeetingData> IMeetingsQueries.GetMeetingsHistory(string username)
        {
            DataTable meetings = Get("SELECT * FROM MEETINGS;");

            List<MeetingData> history = new List<MeetingData>();

            foreach (DataRow meeting in meetings.Rows)
            {
                HashSet<string> participants = new HashSet<string>(meeting["PARTICIPANTS"].ToString().Split(',').ToList());

                if (participants.Contains(username))
                {
                    history.Add(new MeetingData(Convert.ToDateTime(meeting["START"]), Convert.ToDateTime(meeting["END"]), participants));
                }
            }

            return history;
        }
    }

    public class SqlSettingsQueries : SqlDataBaseHandler, ISettingsQueries
    {
        string ISettingsQueries.GetSettings(string username)
        {
            return Get(String.Format("SELECT SETTINGS FROM USERS WHERE USERNAME = '{0}';", username)).Rows[0].ItemArray[0].ToString();
        }

        void ISettingsQueries.UpdateSettings(string username, string settings)
        {
            Set(String.Format("UPDATE USERS SET SETTINGS = '{0}' WHERE USERNAME = '{1}';", settings, username));
        }
    }

    public class SqlDataBase : IDataBase
    {
        private IUsersQueries m_usersTable = new SqlUsersQueries();
        private ISettingsQueries m_settingsTable = new SqlSettingsQueries();
        private IMeetingsQueries m_meetingsTable = new SqlMeetingsQueries();

        ref IUsersQueries IDataBase.GetUsersQueries()
        {
            return ref m_usersTable;
        }

        ref IMeetingsQueries IDataBase.GetMeetingsQueries()
        {
            return ref m_meetingsTable;
        }

        ref ISettingsQueries IDataBase.GetSettingsQueries()
        {
            return ref m_settingsTable;
        }
    }
}
