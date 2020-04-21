create table item
(
	id uuid,
	upc varchar,
	description varchar
);

create unique index item_id_uindex
	on item (id);

alter table item
	add constraint item_pk
		primary key (id);