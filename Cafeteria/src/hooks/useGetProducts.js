import { useEffect, useState } from "react";

const useGetProducts = () => {
  const [data, setData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    setIsLoading(true);
    fetch("http://localhost:5000/api/Product/Products ")
      .then((res) => res.json())
      .then((data) => {
        setData(data);
        setIsLoading(false);
        console.log(data)
      });
  }, []);
  
  return { data, isLoading };
}

export default useGetProducts;