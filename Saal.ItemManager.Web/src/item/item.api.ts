import { Item } from ".";
import { AppConstants } from "../app.constants";

export const getItems = (): Promise<Item[]> => {
  return fetch(`${AppConstants.apiUrl}Items`).then((response) =>
    response.json()
  );
};

export const getItemsByName = (name: string): Promise<Item[]> => {
  return fetch(`${AppConstants.apiUrl}Items?name=${name}`).then((response) =>
    response.json()
  );
};

export const removeItem = (itemId: number): Promise<Response> => {
  return fetch(`${AppConstants.apiUrl}Items?id=${itemId}`, {
    method: "DELETE",
  });
};

export const CreateItem = (item: Item): Promise<Response> => {
  return fetch(`${AppConstants.apiUrl}Items`, {
    method: "POST",
    body: JSON.stringify(item),
  }).then((response) => response.json());
};
