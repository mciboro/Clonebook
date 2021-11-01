import React from "react";
import Header from "components/Header.js";
import { BrowserRouter as Router, Route } from "react-router-dom";
import { useSelector } from "react-redux";
import { Redirect } from 'react-router-dom'

import LoginForm from "pages/account/LoginForm";
import CreateAccountForm from "pages/account/CreateAccountForm";
import PostBrowser from "components/post/PostBrowser";

const App = () => {
  // const serverUrl = "http://localhost:8080/"
  const account = useSelector((state) => state.account); // get redux store values

  return (
    <Router>
      <Header />

      <Route path="/login" exact render={(props) => <LoginForm />} />

      <Route
        path="/createAccount"
        exact
        render={(props) => (
          <>
            <CreateAccountForm />
          </>
        )}
      />
      
      <Route
        path="/my"
        exact
        render={(props) => (
          <>
            {account && account.isLoggedIn && <PostBrowser fetchPostsUrl={`/api/posts/list/user/${account.id}`} />}
            {(!account || !account.isLoggedIn) && <Redirect to='/login' />}
          </>
        )}
      />

      {/* <Route path="/" exact render={(props) => <Browser />} />

      <Route path="/login" exact render={(props) => <LoginForm />} />

      <Route path="/hotels" exact render={(props) => <HotelManager />} />

      <Route
        path="/reservations"
        exact
        render={(props) => (
          <>
            <ReservationsManager />
          </>
        )}
      />
    */}
    </Router>
  );
};

// npm i redux
// npm i react-redux
// npm i redux-thunk
// npm install axios

export default App;
