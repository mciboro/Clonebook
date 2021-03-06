import axios from "axios";

export const login = (email, password, onSuccess = null) => {
  return async (dispatch) => {
    try {
      const result = await axios.post("/api/auth/login", {
        email: email,
        password: password,
      });

      console.log(result);

      if (result && result.data && result.data.success) {
        dispatch({
          type: "SET_LOG_IN",
          payload: {
            id: result.data.id,
            email: result.data.email,
            firstname: result.data.firstname,
            lastname: result.data.lastname,
            roles: result.data.roles,
            token: result.data.token,
          },
        });
        axios.defaults.headers.common["Authorization"] =
          "bearer " + result.data.token;
        if (onSuccess) {
          onSuccess();
        }
      } else {
        dispatch({
          type: "SET_ERRORS",
          payload: {
            errors: [...result.data.errors],
          },
        });
      }
    } catch (e) {
      dispatch({
        type: "SET_ERRORS",
        payload: {
          errors: ["Błąd serwera, spróbuj później"],
        },
      });
    }
  };
};

export const logout = (login, password) => {
  return (dispatch) => {
    dispatch({
      type: "LOG_OUT",
    });
    axios.defaults.headers.common["Authorization"] = null;
  };
};

export const clearErrors = () => {
  return (dispatch) => {
    dispatch({
      type: "CLEAR_ERRORS",
    });
  };
};
