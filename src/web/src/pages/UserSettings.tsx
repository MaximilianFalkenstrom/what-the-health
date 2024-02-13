import { useAuth0 } from "@auth0/auth0-react";
import { useEffect, useState } from "react";
import { useMutation } from "react-query";
import { useNavigate } from "react-router";

const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export default function userSettings() {
  const { getAccessTokenSilently } = useAuth0();
  const navigate = useNavigate();

  const { user } = useAuth0();

  const [userSettingData, setUserSettingData] = useState();

  const [userSetting, setUserSetting] = useState<UserSetting>({
    id: undefined,
    userid: user?.sub,
    name: "",
    birthday: "",
    height: 0,
    weight: 0,
    calories: 0,
  });

  const fetchInfo = async () => {
    const token = await getAccessTokenSilently();
    return fetch(`${baseUrl}/api/usersettings`, {
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
    })
      .then((response) => response.json())
      .then((responseData) => setUserSettingData(responseData));
  };

  useEffect(() => {
    fetchInfo();
    console.log(userSettingData);
  }, []);

  const saveUserSetting = async (userSettings: UserSetting) => {
    const token = await getAccessTokenSilently();

    if (!token) {
      throw new Error("Could not fetch token"); // TODO: Error handling
    }

    return await fetch(`${baseUrl}/api/usersettings`, {
      method: "POST",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(userSettings),
    });
  };

  const mutation = useMutation((userSettings: UserSetting) =>
    saveUserSetting(userSettings)
  );

  const handleCreate = async () => {
    const response = await mutation.mutateAsync(userSetting);

    if (response.ok) {
      const savedUserSettings: UserSetting = await response.json();

      if (savedUserSettings.id) {
        navigate(`/`);
      }
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
          value={userSetting.name}
          onChange={(e) =>
            setUserSetting({ ...userSetting, ["name"]: e.target.value })
          }
        />
      </div>
      <div>
        <label htmlFor="calories">Calories</label>
        <input
          id="calories"
          type="number"
          value={userSetting.calories}
          onChange={(e) =>
            setUserSetting({
              ...userSetting,
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
          value={userSetting.birthday}
          onChange={(e) =>
            setUserSetting({
              ...userSetting,
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
          value={userSetting.height}
          onChange={(e) =>
            setUserSetting({
              ...userSetting,
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
          value={userSetting.weight}
          onChange={(e) =>
            setUserSetting({
              ...userSetting,
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
