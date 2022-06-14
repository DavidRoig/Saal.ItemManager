import * as React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { Item } from "..";
import { ItemRelationComponent } from "./item-relation";

interface Props {
  isOpen: boolean;
  handleClose: () => void;
  handleSave: (newItem: Item) => void;
  items: Item[];
}

export const ItemFormComponent: React.FC<Props> = (props) => {
  const { isOpen, handleClose, handleSave, items } = props;
  const [formValues, setFormValues] = React.useState<Item>(CreateEmptyItem());

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setFormValues({
      ...formValues,
      [id]: value,
    });
  };

  return (
    <div>
      <Dialog open={isOpen} onClose={handleClose}>
        <DialogTitle>Create New Item</DialogTitle>
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
          />
          <TextField
            margin="dense"
            id="type"
            label="Type"
            type="text"
            fullWidth
            variant="standard"
            onChange={handleInputChange}
          />
          <TextField
            margin="dense"
            id="description"
            label="Description"
            type="text"
            fullWidth
            variant="standard"
            onChange={handleInputChange}
          />
          <ItemRelationComponent items={items} />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Cancel</Button>
          <Button
            onClick={() => {
              console.log(formValues);
              handleSave(formValues);
            }}
          >
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

const CreateEmptyItem = (): Item => ({
  id: 0,
  name: "",
  type: "",
  description: "",
  relations: [],
});
