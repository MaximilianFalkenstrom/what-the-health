import { useAuth0 } from "@auth0/auth0-react";
import { useEffect, useState } from "react";
import { useMutation } from "react-query";
import { useNavigate } from "react-router";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function userDetails() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const { user } = useAuth0();

  const [userDetails, setuserDetails] = useState<UserDetails>({
    userid: user?.sub,
    name: "",
    birthday: "",
    height: 0,
    weight: 0,
    calories: 0,
  });

  const fetchInfo = async () => {
    const token = await getAccessTokenSilently();
    return fetch(`${baseUrl}/api/userdetails`, {
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    })
      .then((response) => response.json())
      .then((responseData) => setuserDetails(responseData));
  };

  useEffect(() => {
    fetchInfo();
  }, []);

  const saveUserDetails = async (userDetails: UserDetails) => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }
    if (!userDetails.name) {
      return await fetch(`${baseUrl}/api/userdetails`, {
        method: "POST",
        headers: {
          "content-type": "application/json",
          authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(userDetails),
      });
    }
    return await fetch(`${baseUrl}/api/userdetails`, {
      method: "PATCH",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(userDetails),
    });
  };

  const mutation = useMutation((userDetails: UserDetails) =>
    saveUserDetails(userDetails)
  );

  const handleCreate = async () => {
    const response = await mutation.mutateAsync(userDetails);

    if (response.ok) {
      navigate(`/`);
    }
  };

  if (mutation.isLoading) {
    return <div>Saving...</div>;
  }

  return (
    <div className="form-container">
      <div>
        <label htmlFor="name">Name</label>
        <input
          id="name"
          type="text"
          value={userDetails.name}
          onChange={(e) =>
            setuserDetails({ ...userDetails, ["name"]: e.target.value })
          }
        />
      </div>
      <div>
        <label htmlFor="calories">Calories</label>
        <input
          id="calories"
          type="number"
          value={userDetails.calories}
          onChange={(e) =>
            setuserDetails({
              ...userDetails,
              ["calories"]: parseInt(e.target.value),
            })
          }
        />
      </div>
      <div>
        <label htmlFor="age">Birthday</label>
        <input
          id="age"
          type="date"
          value={userDetails.birthday}
          onChange={(e) =>
            setuserDetails({
              ...userDetails,
              ["birthday"]: e.target.value,
            })
          }
        />
      </div>
      <div>
        <label htmlFor="height">Height</label>
        <input
          id="height"
          type="number"
          value={userDetails.height}
          onChange={(e) =>
            setuserDetails({
              ...userDetails,
              ["height"]: parseInt(e.target.value),
            })
          }
        />
      </div>
      <div>
        <label htmlFor="weight">Weight</label>
        <input
          id="weight"
          type="number"
          value={userDetails.weight}
          onChange={(e) =>
            setuserDetails({
              ...userDetails,
              ["weight"]: parseInt(e.target.value),
            })
          }
        />
      </div>
      <div>
        <button onClick={handleCreate}>Save</button>
      </div>
    </div>
  );
}
