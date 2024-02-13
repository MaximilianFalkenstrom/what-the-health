import { useNavigate } from "react-router";
import "./css/UserDetailsButton.css";

export default function UserDetailsButton() {
  const navigate = useNavigate();

  return (
    <>
      <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
      />
      <div className="userDetails">
        <button
          id="detailsButton"
          className="fa fa-gear"
          onClick={() => navigate("/user/details")}
        ></button>
      </div>
    </>
  );
}
