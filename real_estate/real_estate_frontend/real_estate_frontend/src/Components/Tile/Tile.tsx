import React from 'react'
import house from '../../assets/house.jpg'

type Props = {
  type: string,
  value: string,
  info: string
}

const Tile = ({ type, value, info }: Props) => {
  return (
    <div className = 'tile' >
      <img src ={house} alt ='img'></img>
      <div className ='info'> </div>
            <h2>{type}</h2>
            <p>{value}</p>
      <div className = 'infoDetail' >
        {info}
      </div>
  </div>
  )
}

export default Tile