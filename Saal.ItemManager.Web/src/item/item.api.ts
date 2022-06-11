import { AppConstants } from "../app.constants";

export const getItems = () => {
  return fetch(`${AppConstants.apiUrl}Items`).then((response) =>
    response.json()
  );
};
