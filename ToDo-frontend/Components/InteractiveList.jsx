import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemAvatar from '@mui/material/ListItemAvatar';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Avatar from '@mui/material/Avatar';
import IconButton from '@mui/material/IconButton';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import FolderIcon from '@mui/icons-material/Folder';
import DeleteIcon from '@mui/icons-material/Delete';

const Demo = styled('div')(({ theme }) => ({
  backgroundColor: theme.palette.background.paper,
}));

export default function InteractiveList({list, onDelete}) {
  const [dense, setDense] = React.useState(false);
  const [secondary, setSecondary] = React.useState(true);
  return (
    <Box sx={{ flexGrow: 1, maxWidth: 752 }}>
        <Grid item xs={12} md={6}>
          <Demo>
            <List dense={dense}>
            {
                list.map((element, index) => {
                    return(
                        <ListItem
                        key={element.title + index}
                        secondaryAction={
                          <IconButton onClick={() => onDelete(index)} edge="end" aria-label="delete">
                            <DeleteIcon />
                          </IconButton>
                        }
                      >
                        <ListItemAvatar>
                          <Avatar>
                            <FolderIcon />
                          </Avatar>
                        </ListItemAvatar>
                        <ListItemText sx={{marginX:'24px'}}
                          primary={element.title}
                          secondary={element.description}
                        />
                        <ListItemText sx={{marginX:'24px'}}
                          primary={"Time left: " + Math.floor((new Date(element.due) - Date.now()) / (1000 * 60 * 60 * 24)) + " days"}
                          secondary={Math.floor(((new Date(element.due) - Date.now()) % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)) + " hours"}
                        />
                        <ListItemText sx={{marginX:'24px'}}
                          primary={"Priority: " + element.priority}
                        />
                      </ListItem>
                    )
                })
            }
            </List>
          </Demo>
        </Grid>
    </Box>
  );
}