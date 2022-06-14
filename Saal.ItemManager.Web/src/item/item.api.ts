import { Item } from ".";
import { AppConstants } from "../app.constants";

export const GetItems = (): Promise<Item[]> => {
  return fetch(`${AppConstants.apiUrl}Items`).then((response) =>
    response.json()
  );
};

export const RemoveItem = (itemId: number): Promise<Response> => {
  return fetch(`${AppConstants.apiUrl}Items/${itemId}`, {
    method: "DELETE",
  });
};

export const CreateItem = (item: Item): Promise<Response> => {
  return fetch(`${AppConstants.apiUrl}Items`, {
    headers: {
      "Content-Type": "application/json",
    },
    method: "POST",
    body: JSON.stringify(item),
  }).then((response) => response.json());
};

export const UpdateItem = (item: Item): Promise<Response> => {
  return fetch(`${AppConstants.apiUrl}Items/${item.id}`, {
    headers: {
      "Content-Type": "application/json",
    },
    method: "PUT",
    body: JSON.stringify(item),
  });
};
