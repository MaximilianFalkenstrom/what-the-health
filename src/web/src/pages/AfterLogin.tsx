import { useAuth0 } from "@auth0/auth0-react";
import { fetchUserDetails } from "../queries/UserDetails";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useQuery } from "react-query";

export default function AfterLogin() {
  const navigate = useNavigate();
  const { getAccessTokenSilently } = useAuth0();

  const userDetails = useQuery<UserDetails, Error>(
    "userDetails",
    async () => {
      const token = await getAccessTokenSilently();
      return fetchUserDetails(token);
    },
    {
      retry: false,
      onSuccess: () => {
        navigate("/");
      },
      onError: () => {
        navigate("/user/details");
      },
    }
  );

  useEffect(() => {
    userDetails;
  });

  return <div></div>;
}
