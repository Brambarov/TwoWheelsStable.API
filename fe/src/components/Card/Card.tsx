import { MotorcycleSearch } from '../../../motorcycle';
import './Card.css'

interface Props {
  id: string;
  searchResult: MotorcycleSearch;
}

const Card : React.FC<Props> = ({id, searchResult}: Props) : JSX.Element => {
  return (
    <div className='card'>
        <div className='details'>
          <img alt="Motorcycle picture"/>
            <h2>{searchResult.make}</h2>
            <p>{searchResult.model}</p>
        </div>
        <p className='specs'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Itaque, hic.</p>
    </div>
  )
}

export default Card;