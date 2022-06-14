import * as React from "react";
import Checkbox from "@mui/material/Checkbox";
import TextField from "@mui/material/TextField";
import Autocomplete from "@mui/material/Autocomplete";
import CheckBoxOutlineBlankIcon from "@mui/icons-material/CheckBoxOutlineBlank";
import CheckBoxIcon from "@mui/icons-material/CheckBox";
import { Item } from "..";

const icon = <CheckBoxOutlineBlankIcon fontSize="small" />;
const checkedIcon = <CheckBoxIcon fontSize="small" />;

interface Props {
  items: Item[];
}

export const ItemRelationComponent: React.FC<Props> = (props) => {
  const { items } = props;
  return (
    <>
      {items && (
        <Autocomplete
          multiple
          fullWidth
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
            <TextField {...params} label="Items Related" placeholder="Items" />
          )}
        />
      )}
    </>
  );
};
