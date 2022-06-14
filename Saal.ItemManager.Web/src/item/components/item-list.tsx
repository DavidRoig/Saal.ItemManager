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
  errorHandler: (id: number) => void;
}

export const ItemListComponent: React.FC<Props> = (props) => {
  const { itemList, errorHandler } = props;

  const editHandler = (id: number) => {
    console.info(id);
  };

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
              {item.relations.length > 0 && (
                <Typography gutterBottom variant="body2" component="div">
                  Related with Items: {item.relations.join(",")}
                </Typography>
              )}
            </CardContent>
            <CardActions>
              <IconButton onClick={() => editHandler(item.id)}>
                <CreateIcon />
              </IconButton>
              <IconButton onClick={() => errorHandler(item.id)}>
                <DeleteIcon />
              </IconButton>
            </CardActions>
          </Card>
        );
      })}
    </div>
  );
};
