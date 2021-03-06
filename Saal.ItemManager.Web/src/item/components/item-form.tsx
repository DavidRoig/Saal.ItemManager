import * as React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import Checkbox from "@mui/material/Checkbox";
import Autocomplete from "@mui/material/Autocomplete";
import CheckBoxOutlineBlankIcon from "@mui/icons-material/CheckBoxOutlineBlank";
import CheckBoxIcon from "@mui/icons-material/CheckBox";

import { Item } from "..";

interface Props {
  isOpen: boolean;
  handleClose: () => void;
  handleSave: (newItem: Item) => void;
  items: Item[];
  itemToEdit: Item;
  setItemToEdit: (item: Item) => void;
}

const icon = <CheckBoxOutlineBlankIcon fontSize="small" />;
const checkedIcon = <CheckBoxIcon fontSize="small" />;

export const ItemFormComponent: React.FC<Props> = (props) => {
  const { isOpen, handleClose, handleSave, items, itemToEdit, setItemToEdit } =
    props;

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setItemToEdit({
      ...itemToEdit,
      [id]: value,
    });
  };

  const ItemRelationsOnChangeHandler = (_event, itemsSelected: Item[]) => {
    itemToEdit.relations = itemsSelected.map((item) => item.id);
    setItemToEdit(itemToEdit);
  };

  return (
    <div>
      <Dialog open={isOpen} onClose={handleClose}>
        <DialogTitle>{itemToEdit.id ? "Edit" : "Create"} Item</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Write the details to populate an Item
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            id="name"
            label="Name"
            type="text"
            fullWidth
            variant="standard"
            onChange={handleInputChange}
            value={itemToEdit.name}
          />
          <TextField
            margin="dense"
            id="type"
            label="Type"
            type="text"
            fullWidth
            variant="standard"
            onChange={handleInputChange}
            value={itemToEdit.type}
          />
          <TextField
            margin="dense"
            id="description"
            label="Description"
            type="text"
            fullWidth
            variant="standard"
            onChange={handleInputChange}
            value={itemToEdit.description}
          />
          {items && (
            <Autocomplete
              multiple
              fullWidth
              onChange={ItemRelationsOnChangeHandler}
              options={items}
              disableCloseOnSelect
              getOptionLabel={(option: Item) => option.name}
              renderOption={(props, option, { selected }) => (
                <li {...props}>
                  <Checkbox
                    icon={icon}
                    checkedIcon={checkedIcon}
                    style={{ marginRight: 8 }}
                    checked={selected}
                  />
                  {option.name}
                </li>
              )}
              style={{ paddingTop: "1rem" }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label="Items Related"
                  placeholder="Items"
                />
              )}
            />
          )}
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Cancel</Button>
          <Button
            onClick={() => {
              handleSave(itemToEdit);
            }}
          >
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};
