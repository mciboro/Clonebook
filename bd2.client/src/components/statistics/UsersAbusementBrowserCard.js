import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useParams } from "react-router-dom";

const UsersAbusementBrowserCard = ({userData}) => {

  useEffect(() => {
    console.log(userData);
  }, []);

  return (
    <div>
      <Link to={`/abusements/stats/users/${userData.id}`}>
      <div
        className="container d-flex justify-content-center"
        style={{ "width": 600 }}
      >
        <div
          className="card m-4 p-4 rounded rounded-lg w-100 shadow border rounded-0"
          style={{ border: "#8f8f8fb6" }}
        >
          <div className="text-center">
              <h5>{userData.firstname} {userData.lastname}</h5>
          </div>
        </div>
      </div>
      </Link>
    </div>
  );
};

export default UsersAbusementBrowserCard;