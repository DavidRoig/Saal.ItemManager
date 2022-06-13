import * as React from "react";
import TextField from "@mui/material/TextField";
import Autocomplete from "@mui/material/Autocomplete";
import {
  getItems,
  getItemsByName,
  Item,
  ItemListComponent,
  removeItem,
} from "../item";
import { Box } from "@mui/material";

export const ItemPage: React.FC = () => {
  const [items, setItems] = React.useState<Item[]>([]);
  const [itemsFiltered, setItemsFiltered] = React.useState<Item[]>([]);

  const [itemIdSelected, setItemIdSelected] = React.useState<number>(null);

  React.useEffect(() => {
    getItems().then((items) => {
      setItems(items);
      setItemsFiltered(items);
    });
  }, []);

  React.useEffect(() => {
    if (!itemIdSelected) {
      setItemsFiltered(items);
      return;
    }

    const result = items.filter((item) => item.id === itemIdSelected);

    setItemsFiltered(result);
  }, [itemIdSelected, items]);

  const removeItemHandler = (itemIdToRemove: number) => {
    removeItem(itemIdToRemove).then((response) => {
      if (response.status !== 200) {
        throw new Error("Opps... Item could not be deleted.");
      }

      const itemsAvalable = items.filter((item) => item.id !== itemIdToRemove);
      setItems(itemsAvalable);
    });
  };

  return (
    <Box sx={{ backgroundColor: "whitesmoke", padding: "1rem" }}>
      <Autocomplete
        disablePortal
        id="combo-box-demo"
        options={items}
        getOptionLabel={(option: Item) => option.name || ""}
        sx={{ width: 300 }}
        renderInput={(params) => <TextField {...params} label="Item" />}
        onChange={(e, value: Item) => {
          setItemIdSelected(value?.id);
        }}
      />
      <ItemListComponent
        itemList={itemsFiltered}
        errorHandler={removeItemHandler}
      />
    </Box>
  );
};
