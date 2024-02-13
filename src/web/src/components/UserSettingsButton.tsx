import { useNavigate } from "react-router";
import "./css/UserSettingsButton.css";

export default function UserSettingsButton() {
  const navigate = useNavigate();

  return (
    <>
      <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
      />
      <div className="userSetting">
        <button
          id="settingsButton"
          className="fa fa-gear"
          onClick={() => navigate("/user/settings")}
        ></button>
      </div>
    </>
  );
}
