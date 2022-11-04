import React from 'react';
import {
	CardWrapper,
	CardImage,
	CardTextWrapper,
	CardTextTitle,
	CardStatWrapper,
	CardStats,
	LinkText
  } from "./CardStyles";

function Card(props) {
	return (
		<CardWrapper>
			<CardImage background={props.id} />
			<CardTextWrapper>
			<CardTextTitle>{props.name}</CardTextTitle>
			</CardTextWrapper>
			<CardStatWrapper>
			<CardStats>
				<LinkText href="#">Stock: {props.stock}</LinkText>
			</CardStats>
			<CardStats>
				<LinkText href="#">Price: {props.price}€</LinkText>
			</CardStats>
			</CardStatWrapper>
		</CardWrapper>
	);
}

export default Card;