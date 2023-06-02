import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Link } from 'react-router-dom';
import axios from './axios';

function Investors() {
  const [data, setData] = React.useState([]);

  React.useEffect(() => {
    const getInvestors = async () => {
      axios(
        {
          url: `/investors`,
          method: 'GET'
        }
      ).then(res=> {
        setData(res.data);
      })
    }
    getInvestors();
  }, []);
  return (
    <TableContainer component={Paper} style={{padding: 10}}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>FirmID</TableCell>
            <TableCell align="right">FirmName</TableCell>
            <TableCell align="right">Type</TableCell>
            <TableCell align="right">DataAdded</TableCell>
            <TableCell align="right">Address</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {data.map((row) => (
            <TableRow
              key={row.firmId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              component={Link}
              to={`/Investors/${row.firmId}`}
            >
              <TableCell component="th" scope="row">{row.firmId}</TableCell>
              <TableCell align="right">{row.firmName}</TableCell>
              <TableCell align="right">{row.firmType}</TableCell>
              <TableCell align="right">{row.dataAdded}</TableCell>
              <TableCell align="right">{row.address}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
export default Investors;