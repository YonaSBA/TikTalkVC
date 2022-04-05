using System.Collections.Generic;
using System.Text.Json;

namespace Server
{
    public class AuthenticationHandler : IRequestHandler
    {
        private char m_requestFamily = '1';
        private Authenticator m_authenticatior;
        private RequestHandlerFactory m_requestHandlerFactory;

        public AuthenticationHandler(ref RequestHandlerFactory requestHandlerFactory)
        {
            m_requestHandlerFactory = requestHandlerFactory;
            m_authenticatior = m_requestHandlerFactory.GetAuthenticator();
        }

        public Response HandleRequest(Request info)
        {
            if (info.getFamily() == m_requestFamily)
            {
                switch (info.m_code)
                {
                    case AuthenticationCodes.SIGN_IN:
                        return SignIn(info);
                    case AuthenticationCodes.SIGN_UP:
                        return SignUp(info);
                    case AuthenticationCodes.FORGOT_PASSWORD:
                        return ForgotPassword(info);
                    case AuthenticationCodes.CHANGE_PASSWORD:
                        return ChangePassword(info);
                    default:
                        return new Response(new UnknownRequestException());
                }
            }
            else
            {
                return new Response(new OtherFamilyException());
            }
        }

        private Response SignIn(Request info)
        {
            SignInRequest req = JsonSerializer.Deserialize<SignInRequest>(info.m_data);

            try
            {
                m_authenticatior.SignIn(req.username, req.password);
                return new Response(AuthenticationCodes.SIGN_IN, m_requestHandlerFactory.CreateMenuHandler(req.username)); 
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response SignUp(Request info)
        {
            SignUpRequest req = JsonSerializer.Deserialize<SignUpRequest>(info.m_data);

            try
            {
                m_authenticatior.SignUp(req.username, req.password, req.email);
                return new Response(AuthenticationCodes.SIGN_UP);
            }
            catch (MyException exception)
            {
                return new Response(exception); 
            }
        }

        private Response ForgotPassword(Request info)
        {
            ForgetPasswordRequest req = JsonSerializer.Deserialize<ForgetPasswordRequest>(info.m_data);

            try
            {
                m_authenticatior.ForgotPassword(req.username, req.email);
                return new Response(AuthenticationCodes.FORGOT_PASSWORD);
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        private Response ChangePassword(Request info)
        {
            ChangePasswordRequest req = JsonSerializer.Deserialize<ChangePasswordRequest>(info.m_data);

            try
            {
                m_authenticatior.ChangePassword(req.code, req.password);
                return new Response(AuthenticationCodes.CHANGE_PASSWORD);
            }
            catch (KeyNotFoundException)
            {
                return new Response(new CodeNotExistException());
            }
            catch (MyException exception)
            {
                return new Response(exception);
            }
        }

        public string GetUsername()
        {
            return "";
        }
    }
}
