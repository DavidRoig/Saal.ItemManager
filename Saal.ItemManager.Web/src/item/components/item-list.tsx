import {
  Card,
  CardActions,
  CardContent,
  IconButton,
  Typography,
} from "@mui/material";
import CreateIcon from "@mui/icons-material/Create";
import DeleteIcon from "@mui/icons-material/Delete";

import * as React from "react";
import { Item } from "..";

interface Props {
  itemList: Item[];
  removeHandler: (id: number) => void;
  editHandler: (item: Item) => void;
}

export const ItemListComponent: React.FC<Props> = (props) => {
  const { itemList, removeHandler, editHandler } = props;

  return (
    <div>
      {itemList?.map((item) => {
        return (
          <Card key={item.id} sx={{ maxWidth: 345, margin: "1rem" }}>
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                {item.name}
              </Typography>
              <Typography gutterBottom variant="body1" component="div">
                {item.type}
              </Typography>
              <Typography gutterBottom variant="body2" component="div">
                {item.description}
              </Typography>
            </CardContent>
            {item.relations?.length > 0 && (
              <CardContent>
                <Typography gutterBottom variant="body2" component="div">
                  Ids of related items: {item.relations.join(",")}
                </Typography>
              </CardContent>
            )}
            <CardActions>
              <IconButton onClick={() => editHandler(item)}>
                <CreateIcon />
              </IconButton>
              <IconButton onClick={() => removeHandler(item.id)}>
                <DeleteIcon />
              </IconButton>
            </CardActions>
          </Card>
        );
      })}
    </div>
  );
};
