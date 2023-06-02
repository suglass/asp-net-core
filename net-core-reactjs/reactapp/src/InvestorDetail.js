import * as React from 'react';
import { useParams } from 'react-router-dom';
import axios from './axios';

function InvestorDetail() {
    const {id} = useParams()
    const [data, setData] = React.useState([]);
    React.useEffect(() => {
        const getInvestors = async () => {
          axios(
            {
              url: `/investors/${id}`,
              method: 'GET'
            }
          ).then(res=> {
            setData(res.data);
          })
        }
        getInvestors();
      }, []);
    return (
        <>
            {data.map((row) => (
              <div style={{padding: 10}}>
                <div>{row.firmId}</div>
                <div>{row.firmName}</div>
                <div>{row.firmType}</div>
                <div>{row.dataAdded}</div>
                <div>{row.address}</div>
              </div>
            ))}
        </>
    );
}
export default InvestorDetail;