import * as React from "react";
import TextField from "@mui/material/TextField";
import Autocomplete from "@mui/material/Autocomplete";
import {
  CreateItem,
  GetItems,
  Item,
  ItemFormComponent,
  ItemListComponent,
  RemoveItem,
  UpdateItem,
} from "../item";
import { Box, Button } from "@mui/material";

export const ItemPage: React.FC = () => {
  const [isCreationMode, setIsCreationMode] = React.useState<boolean>(false);
  const [items, setItems] = React.useState<Item[]>([]);
  const [itemsFiltered, setItemsFiltered] = React.useState<Item[]>([]);

  const [itemIdSelected, setItemIdSelected] = React.useState<number>(null);
  const [itemToBeEdited, setItemToBeEdited] = React.useState<Item>(
    CreateEmptyItem()
  );

  React.useEffect(() => {
    GetItems().then((items) => {
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
    RemoveItem(itemIdToRemove).then((response) => {
      if (response.status !== 200) {
        throw new Error("Opps... Item could not be deleted.");
      }

      const itemsAvalable = items.filter((item) => item.id !== itemIdToRemove);
      setItems(itemsAvalable);
    });
  };

  const editItemHandler = (itemToEdit: Item) => {
    setItemToBeEdited(itemToEdit);
    setIsCreationMode(true);
  };

  const openCreationMode = () => {
    setItemToBeEdited(CreateEmptyItem());
    setIsCreationMode(true);
  };

  const closeCreationMode = () => {
    setIsCreationMode(false);
  };

  const SaveItem = (newItem: Item) => {
    if (newItem.id) UpdateItemHandler(newItem);
    else CreateItemHandler(newItem);
  };

  const CreateItemHandler = (item: Item) => {
    CreateItem(item).then((response) => {
      setItems([...items, response]);
      setIsCreationMode(false);
    });
  };

  const UpdateItemHandler = (item: Item) => {
    UpdateItem(item).then((response) => {
      setIsCreationMode(false);
    });
  };

  const autoCompleteOnChangeHandler = (e, value: Item) => {
    setItemIdSelected(value?.id);
  };

  return (
    <Box sx={{ backgroundColor: "whitesmoke", padding: "1rem" }}>
      <Autocomplete
        disablePortal
        options={items}
        getOptionLabel={(option: Item) => option.name || ""}
        sx={{ width: 300 }}
        renderInput={(params) => <TextField {...params} label="Search Items" />}
        onChange={autoCompleteOnChangeHandler}
      />
      <Button
        variant={"contained"}
        onClick={openCreationMode}
        style={{ margin: "1rem 0" }}
      >
        Create New Item
      </Button>
      <ItemFormComponent
        isOpen={isCreationMode}
        items={items}
        handleClose={closeCreationMode}
        handleSave={SaveItem}
        itemToEdit={itemToBeEdited}
        setItemToEdit={setItemToBeEdited}
      />
      <ItemListComponent
        itemList={itemsFiltered}
        removeHandler={removeItemHandler}
        editHandler={editItemHandler}
      />
    </Box>
  );
};

const CreateEmptyItem = (): Item => ({
  id: 0,
  name: "",
  type: "",
  description: "",
  relations: [],
});
  